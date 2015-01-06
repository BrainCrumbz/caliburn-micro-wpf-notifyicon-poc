#caliburn-micro-wpf-notifyicon-poc

Proof of Concepts showing integration between [Caliburn.Micro][Caliburn] WPF MVVM framework and [WPF NotifyIcon][NotifyIcon] system tray UI control.

##Overwiew

This repository contains a few Visual Studio 2013 solutions that progressively show how to integrate WPF NotifyIcon UI control - implementing system tray icon funciontalities - within a WPF MVVM application powered by Caliburn.Micro framework.

The project is aimed in particular at creating a Windows WPF application that starts - and many times stays - as minimised in system tray.

##tl;dr

Solution [04-SysTrayWithinWindow][SysTrayWithinWindow] is a working sample of a Windows WPF application showing the following:

1. NotifyIcon UI control defined in its own View and bound to its ViewModel by means of Caliburn.Micro naming convention
1. NotifyIcon ViewModel started by Caliburn.Micro bootstrapper, with initially hidden View
1. Secondary View (actually, ViewModel) shown and hidden by the system tray ViewModel using Caliburn.Micro WindowManager
1. Inversion of Control by means of [Autofac][Autofac]-enabled bootstrapper

[Caliburn]: http://caliburnmicro.com/
[NotifyIcon]: http://www.hardcodet.net/wpf-notifyicon
[SysTrayWithinWindow]: ./04-SysTrayWithinWindow
[Autofac]: http://autofac.org/
