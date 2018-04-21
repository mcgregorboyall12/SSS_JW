# SSS_JW
JPMorgan Super Simple Stocks c#

# Approach
c# TDD with a WPF/MVVM Light sample application, XUnit with 100% test coverage

# StockCalculator.Core
Contains the entities, interfaces and mock implementations
IStockService is a service that returns some Stock objects
ITradeService is a service which provides events for when a Trade arrives

# StockCalculatorCore.Facts
TDD facts that developed the Core entities, interfaces and mock implementations

# SampleApplication
WPF/MVVMLight consisting of the views only

# ApplicationViewModels.Facts
TDD facts that developed the viewmodels

# ApplicationViewModels
Contains the viewmodels used in the sample application