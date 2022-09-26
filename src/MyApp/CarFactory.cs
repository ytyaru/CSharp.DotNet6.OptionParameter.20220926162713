class CarFactory {
    public IAccelerator create(bool isMT = false) => (isMT) ? new MTCar() : new ATCar();
}
