# How to implement Custom Design System Controls in MAUI 

Did you ever consider building your own custom design system controls in MAUI?

## But Why ? 

Let’s consider an example: I’m part of a company focused on .NET development. 
We have a limited budget and a tight timeline to ship our product. 

If you decide to use a third-party library, consider the following points: licensing, the presence of experienced contributors, compatibility with the latest .NET versions, bug fix support and platform support.

In our case, building a custom library makes sense because our team has the expertise to create it. 

> We prefer to avoid third-party libraries to minimize dependencies, simplify maintenance, and ensure a predictable codebase with updates.

Be able to integrate future unexpected changes from the Product Owner, such as targeting the Windows platform, which a open-source library might not supported.
Failing to consider these aspects could impact your development in the future.

> I will explain step-by-step how to implement a custom design system in MAUI and how to use my open-source project as an external resource to accelerate the development of your own controls.

*Content is on going to give you a step-by-step guide to implement my project in your solution.*

## Articles

- [MAUI (Library Part 1) Create a Custom Entry using SkiaSharp](maui-create-custom-entry-control-with-border)
- [MAUI (Library Part 2) Info & Error states with FluentValidation](maui-info-and-error-states-for-entry)
- [MAUI (Library Part 3) Loading state with Picker Label](maui-loading-state-with-custom-picker)
- [MAUI (Library Part 4) Custom Picker with Collection View and Popup](maui-custom-picker-with-collection-view-popup)
- [MAUI (Library Part 5) Extending Control Behavior with Button](maui-extendind-control-behavior-with-button)
- [Upgrade MAUI to .NET 9.0](upgrade-maui-dotnet-9)
- [MAUI (Library Part 6) Custom Button with Progress Bar](maui-custom-button-with-progress-bar)

## Open Source Community Controls

The open-source community offers strong and resilient advanced libraries, let's have a look.

### [AlohaKit](https://github.com/jsuarezruiz/AlohaKit.Controls)

A set of .NET MAUI drawn controls.

### [SimpleToolkit](https://github.com/RadekVyM/SimpleToolkit)

SimpleToolkit is a .NET MAUI library of helpers and simple, easily customizable controls.

### [UraniumUI](https://github.com/enisn/UraniumUI)

Uranium is a Free & Open-Source UI Kit for .NET MAUI. 
It provides a set of controls and utilities to build modern applications. 
It is built on top of the .NET MAUI infrastructure and provides a set of controls and layouts to build modern UIs. 
It also provides infrastructure for building custom controls and themes on it.

### [MauiToolkit Xceed](https://github.com/xceedsoftware/Xceed-Toolkit-for-.NET-MAUI)

We're thrilled to introduce our new Toolkit for MAUI, an open-source and free version that includes additional controls and features to supplement the existing "basic controls".

### [Syncfusion (Free)](https://github.com/syncfusion/essential-ui-kit-for-.net-maui?tab=readme-ov-file)

The Essential UI Kit for .NET MAUI provides a collection of ready-to-use, customizable, and flexible XAML UI pages tailored for .NET MAUI applications. 

# Check out the latest article on my blog

In this article we enhanced the button component in our MAUI Design System by integrating a Progress Bar with a custom CButton control.

![(Library Part 6) Custom Button with Progress Bar](https://www.stephanarnas.com/images/blog-07.jpg)

This implementation introduces an IsLoading property for visual feedback and demonstrates the integration of the TaskLoaderCommand for state management.

We also addressed button state handling and explored how to bind properties like ShowLoader for seamless UI updates, creating a responsive and interactive user experience.

Happy coding!

![Demo](https://www.stephanarnas.com/images/posts/2025-01-06/03.gif)

Full article here : 
https://www.stephanarnas.com/posts/maui-custom-button-with-progress-bar

