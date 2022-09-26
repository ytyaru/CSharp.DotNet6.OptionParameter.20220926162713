C#でオプション引数を使ってみる

　

<!-- more -->

# ブツ

* [][]

[]:

# コード

```csharp
interface IAccelerator {
    void Accelerator(int gear = -1);
}
```
```csharp
class Car : IAccelerator {
    private int gear;
    protected int Gear {
        get { return this.gear; }
        set { if (0<=value && value<=6) { this.gear = value; } }
    }
    public void Accelerator(int gear = -1) {
        Console.WriteLine("{0}.{1}() {2}", GetType().Name, System.Reflection.MethodBase.GetCurrentMethod().Name, this.Gear);
    }
}
```
```csharp
class ATCar : Car {
    public new void Accelerator(int gear = -1) {
        if (6 == this.Gear) { this.Gear = 0; }
        this.Gear++;
        base.Accelerator();
    }
}
```
```csharp
class MTCar : Car {
    public new void Accelerator(int gear = -1) {
        if (1 == Math.Abs(this.Gear - gear)) {
            Console.WriteLine("{0}.{1}({2}) {3}", 
                GetType().Name, 
                System.Reflection.MethodBase.GetCurrentMethod().Name, 
                gear, this.Gear);
            this.Gear = gear;
        }
        else {
            Console.WriteLine("{0}.{1}({2}) {3} {4}", 
                GetType().Name, 
                System.Reflection.MethodBase.GetCurrentMethod().Name, 
                gear, this.Gear, "エンスト！");
            this.Gear = 0;
        }
    }
}
```
```csharp
Car car = new Car();
ATCar at = new ATCar();
MTCar mt = new MTCar();

car.Accelerator();
car.Accelerator();

Console.WriteLine("---------- AT ----------");

at.Accelerator();
at.Accelerator();
at.Accelerator();
at.Accelerator();
at.Accelerator();
at.Accelerator();
at.Accelerator();

Console.WriteLine("---------- MT ----------");
mt.Accelerator();
mt.Accelerator();
Console.WriteLine("---------- MT 引数あり ----------");
mt.Accelerator(1);
mt.Accelerator(2);
mt.Accelerator(3);
mt.Accelerator(2);
mt.Accelerator(4);
mt.Accelerator(3);
mt.Accelerator(1);

Console.WriteLine("========== Car ==========");

Car at1 = new ATCar();
Car mt1 = new MTCar();
at1.Accelerator(); // Carのものが呼び出される
at1.Accelerator(); // Carのものが呼び出される
mt1.Accelerator(1); // Carのものが呼び出される
mt1.Accelerator(2); // Carのものが呼び出される

Console.WriteLine("========== IAccelerator ==========");

IAccelerator at2 = new ATCar();
IAccelerator mt2 = new MTCar();
at2.Accelerator(); // Carのものが呼び出される
at2.Accelerator(); // Carのものが呼び出される
mt2.Accelerator(1); // Carのものが呼び出される
mt2.Accelerator(2); // Carのものが呼び出される

Console.WriteLine("========== var ==========");

var at3 = new ATCar();
var mt3 = new MTCar();
at3.Accelerator();
at3.Accelerator();
mt3.Accelerator(1); // error CS1501: 引数 1 を指定するメソッド 'Accelerator' のオーバーロードはありません
mt3.Accelerator(2); // error CS1501: 引数 1 を指定するメソッド 'Accelerator' のオーバーロードはありません

Console.WriteLine("========== Factory ==========");

var factory = new CarFactory();
var someCar = factory.create();
someCar.Accelerator();
someCar.Accelerator(1);
someCar.Accelerator(3);
someCar = factory.create(true);
someCar.Accelerator();
someCar.Accelerator(1);
someCar.Accelerator(3);
```

# 結果

```sh
Car.Accelerator() 0
Car.Accelerator() 0
---------- AT ----------
ATCar.Accelerator() 1
ATCar.Accelerator() 2
ATCar.Accelerator() 3
ATCar.Accelerator() 4
ATCar.Accelerator() 5
ATCar.Accelerator() 6
ATCar.Accelerator() 1
---------- MT ----------
MTCar.Accelerator(-1) 0
MTCar.Accelerator(-1) 0
---------- MT 引数あり ----------
MTCar.Accelerator(1) 0
MTCar.Accelerator(2) 1
MTCar.Accelerator(3) 2
MTCar.Accelerator(2) 3
MTCar.Accelerator(4) 2 エンスト！
MTCar.Accelerator(3) 0 エンスト！
MTCar.Accelerator(1) 0
========== Car ==========
ATCar.Accelerator() 0
ATCar.Accelerator() 0
MTCar.Accelerator() 0
MTCar.Accelerator() 0
========== IAccelerator ==========
ATCar.Accelerator() 0
ATCar.Accelerator() 0
MTCar.Accelerator() 0
MTCar.Accelerator() 0
========== var ==========
ATCar.Accelerator() 1
ATCar.Accelerator() 2
MTCar.Accelerator(1) 0
MTCar.Accelerator(2) 1
========== Factory ==========
ATCar.Accelerator() 0
ATCar.Accelerator() 0
ATCar.Accelerator() 0
MTCar.Accelerator() 0
MTCar.Accelerator() 0
MTCar.Accelerator() 0
```

　たいして変化ない。IAccelerator型ではやはりCarの実装が呼ばれているっぽい。

　ググった所、私のやりたいことは多態性（ポリモーフィズム）と呼ぶらしい。次はそのへんでどうにかやってみよう。

