# SSS_JW
JPMorgan Super Simple Stocks c#

## Approach
c# TDD with a WPF/MVVM Light sample application, XUnit tests

## StockCalculator.Core
Contains the business requirement entities, interfaces and mock implementations. 
This project is developed as a .NET Standard library so could be pulled out into a separate nuget package and used cross-platform if required.

IStockService is a service that returns some Stock objects
ITradeService is a service which provides events for when a Trade arrives

In a real-world application it would be possible to create a concrete implementation of the services which use real third party api's etc to pull in real data from the stock exchange, adhering to this interface would mean the layers above should just work.
The project contains two mock services.

## StockCalculatorCore.Facts
TDD facts that developed the Core entities, interfaces and mock implementations. A .NET framework library

## SampleApplication
WPF/MVVMLight application consisting of the views.
The application is not required, but creating a sample application helped me in trying to understand how things might work together. 

The application lists the stock types down the lHS (i.e. TEA, Pop etc.) under each one the fundamentals are listed, stock price, peratio and dividend yield. On the RHS is a mock set of trades, the data which is used to calculate the fundamentals.

## ApplicationViewModels.Facts
TDD facts that developed the viewmodels

## ApplicationViewModels
Contains the viewmodels used in the sample application. A .NET framework library. It is possible to create this project as a .NET standard library by using MVVMLightStd, I would only tend to use that approach if I was going to develop a cross-platform mobile application (where the viewmodel code would be the same)

Assumptions
In the application I have assumed the ticker price was the stock price calculated from the past 15 minute interval