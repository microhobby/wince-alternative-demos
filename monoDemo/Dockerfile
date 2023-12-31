# ARGUMENTS --------------------------------------------------------------------
##
# Board architecture
##
ARG IMAGE_ARCH=

##
# Base container version
##
ARG BASE_VERSION=6.12.0-rc

##
# Application Name
##
ARG APP_EXECUTABLE=monoDemo
# ARGUMENTS --------------------------------------------------------------------



# BUILD ------------------------------------------------------------------------
FROM --platform=linux/${IMAGE_ARCH} \
    commontorizon/mono-sdk:${BASE_VERSION} AS Build

ARG IMAGE_ARCH
ARG APP_EXECUTABLE

COPY . /build
WORKDIR /build

RUN apt-get -y update && apt-get install -y --no-install-recommends \
    # ADD YOUR PACKAGES HERE
# DO NOT REMOVE THIS LABEL: this is used for VS Code automation
    # __torizon_packages_dev_start__
	libgpiod-dev:arm64 \
    # __torizon_packages_dev_end__
# DO NOT REMOVE THIS LABEL: this is used for VS Code automation
    && \
	&& apt-get clean && apt-get autoremove && rm -rf /var/lib/apt/lists/*

# build
RUN msbuild

# BUILD ------------------------------------------------------------------------



# DEPLOY -----------------------------------------------------------------------
FROM --platform=linux/${IMAGE_ARCH} \
    commontorizon/mono-runtime:${BASE_VERSION} AS Deploy

ARG IMAGE_ARCH
ARG APP_EXECUTABLE
ENV APP_EXECUTABLE ${APP_EXECUTABLE}

RUN apt-get -y update && apt-get install -y --no-install-recommends \
    # ADD YOUR PACKAGES HERE
# DO NOT REMOVE THIS LABEL: this is used for VS Code automation
    # __torizon_packages_prod_start__
    # __torizon_packages_prod_end__
# DO NOT REMOVE THIS LABEL: this is used for VS Code automation
    && \
	&& apt-get clean && apt-get autoremove && rm -rf /var/lib/apt/lists/*

# copy the build
COPY --from=Build /build/bin/Debug /app

# ADD YOUR ARGUMENTS HERE
CMD [ "mono", "./app/monoDemo.exe" ]

# DEPLOY -----------------------------------------------------------------------
