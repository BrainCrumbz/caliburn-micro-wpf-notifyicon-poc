#caliburn-micro-wpf-notifyicon-poc

Proof of Concepts showing integration between [Caliburn.Micro][Caliburn] WPF MVVM framework and [WPF NotifyIcon][NotifyIcon] system tray UI control.

##PoC 04 is the proposed final working solution!

###tl;dr

[04-SysTrayWithinWindow][04-SysTrayWithinWindow] Visual Studio solution is a working sample of a Windows WPF application showing the following:

1. NotifyIcon UI control defined in its own View and bound to its ViewModel by means of Caliburn.Micro naming convention, *ViewModel first*
1. NotifyIcon ViewModel started by Caliburn.Micro Bootstrapper, with initially hidden View
1. Secondary View (actually, ViewModel) shown and hidden by the system tray ViewModel using Caliburn.Micro WindowManager
1. Inversion of Control by means of [Autofac][Autofac]-enabled Bootstrapper

##Overwiew

This repository contains a few Visual Studio 2013 solutions that progressively show how to integrate WPF NotifyIcon UI control - implementing system tray icon funciontalities - within a WPF MVVM application powered by Caliburn.Micro framework.

The project is aimed in particular at creating a Windows WPF application that starts - and many times stays - as minimised in system tray. *ViewModel first* approach is favored over *View first*.

##Solutions

Presented solutions were created one after the other, each one trying to solve one facet of the integration at a time, and each one building on top of previous results.

###01-SysTrayNoWindow

[01-SysTrayNoWindow][01-SysTrayNoWindow] solution shows that you can add WPF NotifyIcon to your Caliburn.Micro-enabled WPF application. UI control is added as a resource to the main App XAML, following WPF NotifyIcon tutorials, and thus it is instantiated within Bootstrapper which is not usually *the Caliburn way* of doing.

The system tray icon isn't bound to anything, so it can't perform any action at the moment: you just see the icon when running and in order to close the app you have to kill it or stop debugging.

###02-SysTrayOpenWindow

[02-SysTrayOpenWindow][02-SysTrayOpenWindow] solution adds a ViewModel bound to NotifyIcon UI control. ViewModel is bound by means of the same XAML defining the icon resource, again without taking advantage of Caliburn.Micro way of coupling Views and ViewModels.

System tray menu is now able to show/hide another window, but this happens without recurring to Caliburn.Micro navigation mechanism (e.g. `WindowManager`). Instead it works by means of classic WPF `Application.Current.MainWindow` property. And the second window is still a classic WPF Window with code-behind, not a View/ViewModel couple.

For some reason, while system tray menu commands are successfully bound with Caliburn.Micro `Message.Attach`, binding on icon double-click event doesn't work, not even when following what's suggested [here][SO-doubleclick].

NotifyIcon UI control is still instantiated by Bootstrapper.

###03-SysTrayOpenViewModel

[03-SysTrayOpenViewModel][03-SysTrayOpenViewModel] solution starts to implement some of Caliburn.Micro specific rules and conventions.

NotifyIcon UI control is still instantiated by Bootstrapper, but its ViewModel is not bound by XAML anymore, instead it's manually set by code in Bootstrapper. Not yet the Caliburn.Micro standard way, though.

The other window is now actually a View/ViewModel couple, following Caliburn naming convention, and system tray menu is now showing/hiding it by means of Caliburn.Micro `WindowManager`. Double-click event, in order to work, still has to be bound to a WPF classic `ICommand` implementation.

All dependencies are injected and registered with Autofac IoC container, completely integrated within Bootstrapper.

###04-SysTrayWithinWindow

[04-SysTrayWithinWindow][04-SysTrayWithinWindow] solution fully integrates WPF NotifyIcon UI control with Caliburn.Micro way of building WPF applications.

Notify UI control is not defined as an app-wide resource anymore, and is not instantiated by Bootstrapper anymore. It is now defined and instantiated in its own dedicated View as any other UI control. 

The system tray View is also the application root View, and is set to always be completely invisible. It is bound to its ViewModel by naming convetion, and set as root within Bootstrapper following Caliburn.Micro standard.

(Probably due to the regular binding in place between root View and ViewModel) Now double-click event on system tray icon can be bound through a Caliburn `Message.Attach` expression, so there are no more `ICommand` implementations in ViewModel.

As a side note, system tray icon can be different than the task bar icon (when secondary View is visible).

[Caliburn]: http://caliburnmicro.com/
[NotifyIcon]: http://www.hardcodet.net/wpf-notifyicon
[01-SysTrayNoWindow]: ./01-SysTrayNoWindow
[02-SysTrayOpenWindow]: ./02-SysTrayOpenWindow
[03-SysTrayOpenViewModel]: ./03-SysTrayOpenViewModel
[04-SysTrayWithinWindow]: ./04-SysTrayWithinWindow
[Autofac]: http://autofac.org/
[SO-doubleclick]: http://stackoverflow.com/questions/19447515/double-click-wpfnotifyicon-with-caliburn-micro
