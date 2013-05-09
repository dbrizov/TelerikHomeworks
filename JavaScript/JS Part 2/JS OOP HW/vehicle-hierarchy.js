// PropulsionUnit - abstract
function PropulsionUnit() {
}

PropulsionUnit.prototype = {
    constructor: PropulsionUnit,
    getAcceleration: function getAcceleration() {
        return 0;
    }
}

// Wheel - inherits PropulsionUnit
function Wheel(radius) {
    this.radius = radius;
}

Wheel.prototype = new PropulsionUnit();
Wheel.prototype.constructor = Wheel;
Wheel.prototype.getAcceleration = function getAcceleration() {
    var perimeter = 2 * Math.PI * this.radius;
    return perimeter;
}

// PropellingNozzle - inherits PropulsionUnit
function PropellingNozzle(power, afterburnerIsOn) {
    this.power = power;
    this.afterburnerIsOn = afterburnerIsOn;
}

PropellingNozzle.prototype = new PropulsionUnit();
PropellingNozzle.prototype.constructor = PropellingNozzle;
PropellingNozzle.prototype.getAcceleration = function getAcceleration() {
    if (this.afterburnerIsOn) {
        return this.power * 2;
    }
    else {
        return this.power;
    }
}

// Propeller - inherits PropulsionUnit
function Propeller(finsCount, spinDirectionIsClockwise) {
    this.finsCount = finsCount;
    this.spinDirectionIsClockwise = spinDirectionIsClockwise;
}

Propeller.prototype = new PropulsionUnit();
Propeller.prototype.constructor = Propeller;
Propeller.prototype.getAcceleration = function getAcceleration() {
    if (this.spinDirectionIsClockwise) {
        return this.finsCount;
    }
    else {
        return (-this.finsCount);
    }
}

// Vehicle
function Vehicle(speed, propulsionUnits) {
    this.speed = speed;
    this.propulsionUnits = propulsionUnits;
}

Vehicle.prototype.accelerate = function accelerate() {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.speed += this.propulsionUnits[i].getAcceleration();
    }
}

// LandVehicle - inherits Vehicle
function LandVehicle(speed, wheelsRadius) {
    this.propulsionUnits = new Array();
    for (var i = 0; i < 4; i++) {
        this.propulsionUnits.push(new Wheel(wheelsRadius));
    }

    /* properties inheritance */
    Vehicle.call(this, speed, this.propulsionUnits);
}

/* methods inheritance */
LandVehicle.prototype = new Vehicle();
LandVehicle.prototype.constructor = LandVehicle;

// AirVehicle - inherits Vehicle
function AirVehicle(speed, nozzlePower, nozzleAfterburnerIsOne) {
    this.propulsionUnits = [new PropellingNozzle(nozzlePower, nozzleAfterburnerIsOne)];

    /* properties inheritance */
    Vehicle.call(this, speed, this.propulsionUnits);
}

/* methods inheritance */
AirVehicle.prototype = new Vehicle();
AirVehicle.prototype.constructor = AirVehicle;

AirVehicle.prototype.switchAfterburnerOn  = function switchAfterburnerOn() {
    this.propulsionUnits[0].afterburnerIsOn = true;
}

AirVehicle.prototype.switchAfterburnerOff = function switchAfterburnerOff() {
    this.propulsionUnits[0].afterburnerIsOn = false;
}

// WaterVehicles - inherits Vehicle
function WaterVehicle(
        speed,
        propellersCount,
        propellersFinsCount,
        propellersSpinDirectionIsClockwise) {
    this.propulsionUnits = new Array(propellersCount);
    for (var i = 0; i < propellersCount; i++) {
        this.propulsionUnits[i] = new Propeller(propellersFinsCount, propellersSpinDirectionIsClockwise);
    }

    /* properties inheritance */
    Vehicle.call(this, speed, this.propulsionUnits);
}

/* methods inheritance */
WaterVehicle.prototype = new Vehicle();
WaterVehicle.prototype.constructor = WaterVehicle;

WaterVehicle.prototype.makePropellersSpinDirectionClockwise = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.propulsionUnits[i].spinDirectionIsClockwise = true;
    }
}

WaterVehicle.prototype.makePropellersSpinDirectionCounterClockwise = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.propulsionUnits[i].spinDirectionIsClockwise = false;
    }
}

// HybridVehicle - inherits LandVehicle and WaterVehicle
function HybridVehicle(
        speed,
        wheelsRadius,
        propellersCount,
        propellersFinsCount,
        propellersSpinDirectionIsClockwise) {

    this.landPropulsionUnits = new Array();
    for (var i = 0; i < 4; i++) {
        this.landPropulsionUnits.push(new Wheel(wheelsRadius));
    }

    this.waterPropulsionUnits = new Array(propellersCount);
    for (var i = 0; i < propellersCount; i++) {
        this.waterPropulsionUnits[i] = new Propeller(propellersFinsCount, propellersSpinDirectionIsClockwise);
    }

    this.landModeIsOn = true;
    this.waterModeIsOn = false;

    // Inherits the properties from LandVehicle
    LandVehicle.call(this, speed, wheelsRadius);

    // Inherits the properties from WaterVehicle - unfortunately,
    // we have double initialization of the speed property, which is
    // not such a big problem, because it is overriden
    WaterVehicle.call(
        this,
        speed,
        propellersCount,
        propellersFinsCount,
        propellersSpinDirectionIsClockwise);
}

Function.prototype.extend = function (parent) {
    var parentPrototype = parent.prototype;

    for (var i in parentPrototype) {
        this.prototype[i] = parentPrototype[i];
    }

    return this;
}

// Inherit the methods from LandVehicle
HybridVehicle.extend(LandVehicle);
HybridVehicle.extend(WaterVehicle);

HybridVehicle.prototype.switchToLandMode = function () {
    this.landModeIsOn = true;
    this.waterModeIsOn = false;
}

HybridVehicle.prototype.switchToWaterMode = function () {
    this.landModeIsOn = false;
    this.waterModeIsOn = true;
}

HybridVehicle.prototype.accelerate = function () {
    if (this.landModeIsOn) {
        for (var i = 0; i < this.landPropulsionUnits.length; i++) {
            this.speed += this.landPropulsionUnits[i].getAcceleration();
        }
    }
    else {
        for (var i = 0; i < this.waterPropulsionUnits.length; i++) {
            this.speed += this.waterPropulsionUnits[i].getAcceleration();
        }
    }
}

HybridVehicle.prototype.makePropellersSpinDirectionClockwise = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.waterPropulsionUnits[i].spinDirectionIsClockwise = true;
    }
}

HybridVehicle.prototype.makePropellersSpinDirectionCounterClockwise = function () {
    for (var i = 0; i < this.propulsionUnits.length; i++) {
        this.waterPropulsionUnits[i].spinDirectionIsClockwise = false;
    }
}

// Vehicle tests
// LAND VEHIVLE
console.log("LAND VEHICLE:");
var landVehicle = new LandVehicle(10, 1);
console.log(landVehicle.speed); // 10
landVehicle.accelerate(); // speed = speed + 4 (2 * Math.PI * 1) = 10 + 4 * 6.28 = 25.12
console.log(landVehicle.speed); // 35.12

// AIR VEHCILE
console.log("AIR VEHICLE:")
var airVehicle = new AirVehicle(10, 5, true);
console.log(airVehicle.speed); // 10
airVehicle.accelerate(); // speed = speed + 2 * power = 10 + 2 * 5 = 20
console.log(airVehicle.speed); // 20;

airVehicle.switchAfterburnerOff();

airVehicle.accelerate(); // speed = speed + power = 20 + 5 = 25
console.log(airVehicle.speed);

// WATER VEHICLE
console.log("WATER VEHICLE:");
var waterVehicle = new WaterVehicle(10, 2, 5, true);
console.log(waterVehicle.speed); // 10
waterVehicle.accelerate(); // speed = speed + 2 * 5 = 10 + 10 = 20
console.log(waterVehicle.speed); // 20

waterVehicle.makePropellersSpinDirectionCounterClockwise();

waterVehicle.accelerate(); // speed = speed + 2 * (-5) = 20 - 10 = 10
console.log(waterVehicle.speed);

// HYBRID VEHICLE
console.log("HYBRID VEHICLE");
var hybridVehicle = new HybridVehicle(0, 1, 2, 5, true); // by default the landMode is ON
console.log(hybridVehicle.speed); // 0
hybridVehicle.accelerate(); // speed = speed + 4 * (2 * Math.PIP * 1) = 0 + 25.12 = 25.12 (because landMode is ON)
console.log(hybridVehicle.speed); // 25.12

hybridVehicle.speed = 0;
hybridVehicle.switchToWaterMode();
hybridVehicle.accelerate(); // speed = speed + 2 * 5 = 0 + 10 = 10 (because waterMode is ON)
console.log(hybridVehicle.speed); // 10
hybridVehicle.makePropellersSpinDirectionCounterClockwise();
hybridVehicle.accelerate(); // speed = speed + 2 * (-5) = 10 - 10 = 0;
console.log(hybridVehicle.speed); // 0