#   make build | test | test-unit [PRODUCTS="spot common"] [CONFIG=Release] [FILTER=<dotnet test filter>]
#   make native-download [NATIVE_RID=<rid>] # the library of native-version.txt; `make test` then uses it
#   make native                            # build it from the C++ sources instead (to change the C API)
#   make examples PRODUCT=spot             # list the examples of a product
#   make example NAME=spot/RestApi/Market/Ticker
#   make format | format-check | pack | docs | slnx | clean

.PHONY: help restore build test test-unit native native-download examples example format format-check pack docs slnx clean

CONFIG     ?= Debug
PRODUCTS   ?=
FILTER     ?=
NATIVE_SRC ?= ../binance-connector-cpp
NATIVE_DIR ?= build/native
SOLUTION   := Binance.slnx
LIB_EXT    := $(if $(filter Darwin,$(shell uname -s)),dylib,so)
NATIVE_LIB := $(CURDIR)/$(NATIVE_DIR)/c_api/libbinance_c.$(LIB_EXT)
NATIVE_VERSION := $(strip $(shell cat src/Binance.Common/native-version.txt))
NATIVE_REPO    ?= binance/binance-connector-cpp
NATIVE_URL     ?= https://github.com/$(NATIVE_REPO)/releases/download

NATIVE_OS   := $(shell uname -s)
NATIVE_ARCH := $(shell uname -m)
NATIVE_LIBC := $(if $(filter Linux,$(NATIVE_OS)),$(if $(shell ldd --version 2>&1 | grep -i musl),musl-))
NATIVE_RID  ?= $(strip \
	$(if $(filter Darwin,$(NATIVE_OS)),osx-$(if $(filter arm64,$(NATIVE_ARCH)),arm64,x64), \
	$(if $(filter Linux,$(NATIVE_OS)),linux-$(NATIVE_LIBC)$(if $(filter aarch64 arm64,$(NATIVE_ARCH)),arm64,$(if $(filter armv7l armv7 armhf,$(NATIVE_ARCH)),arm,x64)), \
	unsupported)))

match = $(strip $(foreach d,$(2),$(if $(filter $(subst _,,$(1)),$(shell printf '%s' '$(notdir $(d))' | sed 's/^Binance\.//; s/\.Examples$$//; s/\.Tests$$//; s/\.//g' | tr 'A-Z' 'a-z')),$(d))))
client_dir   = $(call match,$(1),$(wildcard src/Binance.*))
examples_dir = $(call match,$(1),$(wildcard examples/Binance.*.Examples))
tests_dir    = $(call match,$(1),$(wildcard tests/Binance.*.Tests))

product_projects = $(wildcard $(foreach p,$(1),$(if $(filter common,$(p)), \
	src/Binance.Common/*.csproj src/Binance.Common.DependencyInjection/*.csproj tests/Binance.Common.Tests/*.csproj, \
	$(call client_dir,$(p))/*.csproj $(call examples_dir,$(p))/*.csproj $(call tests_dir,$(p))/*.csproj)))
test_projects = $(wildcard $(foreach p,$(1),$(if $(filter common,$(p)),tests/Binance.Common.Tests/*.csproj,$(call tests_dir,$(p))/*.csproj)))

BUILD_TARGETS = $(if $(PRODUCTS),$(call product_projects,$(PRODUCTS)),$(SOLUTION))
TEST_TARGETS  = $(if $(PRODUCTS),$(call test_projects,$(PRODUCTS)),$(SOLUTION))

export BINANCE_C_LIB ?= $(if $(wildcard $(NATIVE_LIB)),$(NATIVE_LIB))

help:
	@awk '/^#/ { sub(/^# ?/, ""); print; next } { exit }' $(firstword $(MAKEFILE_LIST))

restore:
	dotnet restore $(SOLUTION)

build:
	@test -n "$(strip $(BUILD_TARGETS))" || { echo "No project found for PRODUCTS=\"$(PRODUCTS)\""; exit 1; }
	@for p in $(BUILD_TARGETS); do \
		echo "dotnet build $$p -c $(CONFIG)"; dotnet build "$$p" -c $(CONFIG) || exit 1; \
	done

test: build
	@test -n "$$BINANCE_C_LIB" || { echo "The Native tests need the platform library: run 'make native' or set BINANCE_C_LIB (or use 'make test-unit')."; exit 1; }
	@for p in $(TEST_TARGETS); do \
		echo "dotnet test $$p -c $(CONFIG)"; \
		dotnet test "$$p" -c $(CONFIG) --no-build $(if $(FILTER),--filter "$(FILTER)") || exit 1; \
	done

test-unit: build
	@for p in $(TEST_TARGETS); do \
		echo "dotnet test $$p -c $(CONFIG) (without the Native category)"; \
		dotnet test "$$p" -c $(CONFIG) --no-build --filter "Category!=Native$(if $(FILTER),&($(FILTER)))" || exit 1; \
	done

native:
	@test -f "$(NATIVE_SRC)/c_api/CMakeLists.txt" || { echo "No C API in $(NATIVE_SRC): clone https://github.com/$(NATIVE_REPO) there, or set NATIVE_SRC=<path> (or use 'make native-download')"; exit 1; }
	@v=$$(sed -n -E 's/^    VERSION ([0-9.]+)$$/\1/p' "$(NATIVE_SRC)/CMakeLists.txt" | head -n 1); \
	if [ "$$v" != "$(NATIVE_VERSION)" ]; then echo "Note: $(NATIVE_SRC) is version $$v; the packages ship $(NATIVE_VERSION) (src/Binance.Common/native-version.txt)"; fi
	cmake --preset release -S "$(NATIVE_SRC)" -B "$(NATIVE_DIR)" -DBINANCE_PRODUCTS="" -DBINANCE_BUILD_C_API=ON
	cmake --build "$(NATIVE_DIR)" --target binance_c
	@echo "Platform library: $(NATIVE_LIB)"

native-download:
	@test "$(NATIVE_RID)" != unsupported || { echo "No released library for $(NATIVE_OS) $(NATIVE_ARCH): set NATIVE_RID=<rid>, or build it with 'make native'"; exit 1; }
	@mkdir -p "$(NATIVE_DIR)/c_api"
	curl -fsSL -o "$(NATIVE_DIR)/binance_c.zip" \
		"$(NATIVE_URL)/v$(NATIVE_VERSION)/binance_c-$(NATIVE_VERSION)-$(NATIVE_RID).zip"
	unzip -o -q "$(NATIVE_DIR)/binance_c.zip" -d "$(NATIVE_DIR)/c_api"
	@rm -f "$(NATIVE_DIR)/binance_c.zip"
	@echo "Platform library $(NATIVE_VERSION) for $(NATIVE_RID): $(NATIVE_LIB)"

examples:
	@test -n "$(PRODUCT)" || { echo "Usage: make examples PRODUCT=<product>"; exit 1; }
	@test -f "$(call examples_dir,$(PRODUCT))/Program.cs" || { echo "No examples for '$(PRODUCT)'"; exit 1; }
	@sed -n 's/^ *\["\([^"]*\)"\].*/$(PRODUCT)\/\1/p' $(call examples_dir,$(PRODUCT))/Program.cs

example:
	@test -n "$(NAME)" || { echo "Usage: make example NAME=<product>/<module>/<api>/<name> (see 'make examples PRODUCT=<product>')"; exit 1; }
	dotnet run --project $(call examples_dir,$(firstword $(subst /, ,$(NAME)))) -c $(CONFIG) -- $(patsubst $(firstword $(subst /, ,$(NAME)))/%,%,$(NAME))

format:
	dotnet format whitespace $(SOLUTION)

format-check:
	dotnet format whitespace $(SOLUTION) --verify-no-changes

pack:
	dotnet pack $(SOLUTION) -c Release -o artifacts

docs:
	sh scripts/update-docs-connectors.sh
	docfx docfx.json

slnx:
	sh scripts/update-slnx.sh

clean:
	dotnet clean $(SOLUTION) -c $(CONFIG) > /dev/null || :
	find src examples tests -type d \( -name bin -o -name obj \) -prune -exec rm -rf {} +
	rm -rf artifacts $(NATIVE_DIR)
