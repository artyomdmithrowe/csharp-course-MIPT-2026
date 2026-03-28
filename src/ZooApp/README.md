# Moscow Zoo ERP

Консольное приложение для учета животных и инвентаря Московского зоопарка.

Файл с требованиями: [Требования.pdf](./Requirements.pdf)

## Структура проекта

```text
src/ZooApp
  Interfaces
  Models
    Animals
    Things
    Zoo
  Services
  Program.cs
  ZooApp.csproj

tests/ZooApp.Tests
  DomainModelTests.cs
  InventoryStorageTests.cs
  VeterinaryServiceTests.cs
  ZooTests.cs
```

## Основные идеи решения

- `Zoo` является основным доменным сервисом, в нем реализована бизнес-логика. `Zoo` работает через зависимости:
  - `IVeterinaryProvider`
  - `IInventoryStorage`
- `InventoryStorage` реализует `IInventoryStorage`. `InventoryStorage` хранит весь инвентарь и контролирует уникальность инвентарных номеров.
- `VeterinaryService` реализует `IVeterinaryProvider`. `VeterinaryService` проверяет здоровье животного и дружелюбность травоядного.
- `Animal` и `Thing` реализуют `IInventory`, потому что и вещи, и животные подлежат инвентаризации.
- `Animal` реализует `IAlive`, потому что животные относятся к категории «живых».
- `Herbo` содержит `Kindness`, по которому определяется возможность помещения в контактный зоопарк.
- `Animal`, `Herbo`, `Predator` и `Thing` являются абстрактными классами, потому что мы не можем создавать объекты этих классов.
- `Animal`, `Thing` и `Herbo` имеют переопределенный метод `ToString` для удобного вывода информации в консоль.

## Где применены принципы SOLID

### Single Responsibility Principle

- `Zoo` отвечает за операции предметной области зоопарка.
- `InventoryStorage` отвечает за хранение инвентаря.
- `VeterinaryService` отвечает за ветеринарные проверки.

### Open/Closed Principle

- Новые виды животных и вещей можно добавлять через наследование от существующих базовых классов без изменения уже написанной логики.
- `Monkey` и `Computer` являются примером этого.

### Liskov Substitution Principle

- `Rabbit`, `Monkey`, `Tiger`, `Wolf`, `Table`, `Computer` могут использоваться вместо своих базовых типов (`Animal`, `Herbo`, `Predator`, `Thing`).

### Interface Segregation Principle

- Используются следующие узкопрофильные интерфейсы:
  - `IAlive`
  - `IInventory`
  - `IInventoryStorage`
  - `IVeterinaryProvider`

### Dependency Inversion Principle

- `Zoo` зависит от абстракций (`IVeterinaryProvider`, `IInventoryStorage`), а не от конкретных реализаций.
- Конкретные реализации подключаются через DI-контейнер в [Program.cs](./Program.cs).

## DI-контейнер

В проекте используется `Microsoft.Extensions.DependencyInjection`, выполнение которого выполняется в [Program.cs](./Program.cs).

## Запуск приложения

Из корня репозитория:

```powershell
dotnet run --project .\src\ZooApp\ZooApp.csproj
```

## Запуск тестов

Из корня репозитория:

```powershell
dotnet test .\tests\ZooApp.Tests\ZooApp.Tests.csproj
```

## Покрытие тестами

Из корня репозитория:

```powershell
dotnet test .\tests\ZooApp.Tests\ZooApp.Tests.csproj --collect:"XPlat Code Coverage"
```

По текущему состоянию проекта покрытие строк составляет 60.00%, а покрытие ветвлений - 81.81%.
Тестами покрыты доменные модели `Animal`, `Herbo`, `Thing`, логика `Zoo`, а также сервисы `InventoryStorage` и `VeterinaryService`.

## Что демонстрирует Program.cs

- добавление корректных животных
- отказ в добавлении нездорового животного
- отказ в создании сущности с невалидным номером
- отказ при попытке добавить объект с уже существующим инвентарным номером
- вывод статистики по животным
- вывод животных для контактного зоопарка
- вывод вещей
