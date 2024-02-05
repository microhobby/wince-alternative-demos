# .NET 8 C# Uno Platform 5.x Skia.GTK Template Specific Documentation


> ⚠️ **WARNING:**  This is just the documentation part specific of this template. **For the complete and general Torizon IDE documentation, check the [developer website documentation](https://developer.toradex.com/torizon/application-development/ide-extension/)** ⚠️

All projects follow the pipeline of tasks described in the [common contributing documentation](https://github.com/toradex/vscode-torizon-templates/blob/bookworm/CONTRIBUTING.md#contributing-templates). However, each project has its own specificities in terms of technologies and methods used to compile, deploy, and debug the code. Therefore, each of them has their own specific tasks in the **tasks.json** file.

## Specific Tasks

### build-skia-gtk

Build the `<project-name>.Skia.Gtk.csproj` project with the `dotnet build` command. This is a task that comes from the original Uno Platform template.

### publish-skia-gtk

Publish the `<project-name>.Skia.Gtk.csproj` project with the `dotnet publish -c Debug` command. This is a task that comes from the original Uno Platform template.

### open-skia-gtk-csproj

The Uno Platform extension need a specific platform project to be select as the startup project. This task opens a picker with a list of the available `<project-name>.Skia.Gtk.csproj` to be selected.

![open-skia-gtk-csproj task](https://github.com/toradex/vscode-torizon-templates-documentation/blob/bookworm/dotnetUno5/open-skia-gtk-csproj.jpg?raw=true)

Select the `<project-name>.Skia.Gtk.csproj` and press enter to load it.

> ⚠️ Without selecting the `<project-name>.Skia.Gtk.csproj` as the startup project, the Uno Platform extension will not show code completions and tips for the XAML files.

### reload-skia-gtk-csproj

This task reloads the `<project-name>.Skia.Gtk.csproj` project.

![reload-skia-gtk-csproj task](https://github.com/toradex/vscode-torizon-templates-documentation/blob/bookworm/dotnetUno5/reload-skia-gtk-csproj.jpg?raw=true)

> ⚠️ [There is an issue](https://github.com/unoplatform/uno/issues/14710) with the Uno Platform source generator and the C# extension that does not refresh the symbols generated for the XAML code behind. So, if you change the XAML and the symbols are being shown as not found, you can use this task to reload the project and refresh the symbols.

### config-hot-reload-address

For the XAML Hot Reload feature to work remotely, running on the Torizon device, the Uno Platform framework needs to know the IP address of the development PC. This task automatically configures the IP address of the development PC in the `<project-name>.Skia.Gtk.csproj`. It's good to run this task always when opening the project.

![config-hot-reload-address task](https://github.com/toradex/vscode-torizon-templates-documentation/blob/bookworm/dotnetUno5/config-hot-reload-address.jpg?raw=true)

> ⚠️ Uno Platform XAML hot reload [is not supported during debug sessions](https://platform.uno/docs/articles/features/working-with-xaml-hot-reload.html?tabs=vscode%2Cskia#vs-code). So, if you want to launch the application on the Torizon device and use the XAML hot reload feature, select the desired `Torizon <arch>` on the `Run and Debug` activity bar, as you would start a normal debug session, and then press `Ctrl+F5` instead only `F5` to launch the application remottly but without debugging.

## Fullscreen Kiosk Mode

The template comes with two window modes: `Windowed` and `Fullscreen`. The `Windowed` mode is the default one when using it locally on the development PC. The `Fullscreen` mode is the default one when using it remotly on the Torizon device. However, it is possible to change this behavior by modifying, or adding, the `UNO_FULLSCREEN` environment variable. The `UNO_FULLSCREEN` environment variable can be set to `true` or `false`, string value, to force the application to start in `Fullscreen` or `Windowed` mode, respectively.

The files where this environment variable is set are:

- `.vscode/launch.json` for the default `F5` debug remote session;
- `Dockerfile` for the production container image;
