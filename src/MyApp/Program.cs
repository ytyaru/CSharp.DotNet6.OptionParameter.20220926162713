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

