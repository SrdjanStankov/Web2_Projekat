"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var time_1 = require("../util/time");
var Flight = /** @class */ (function () {
    function Flight() {
        this.departureTime = new Date();
        this.arrivalTime = new Date();
    }
    Object.defineProperty(Flight.prototype, "travelTime", {
        /**
         * Returns difference between departure and arrival time in milliseconds
         */
        get: function () {
            var diff = this.arrivalTime.valueOf() - this.departureTime.valueOf();
            // Math.abs is used due to possible country date/time differences
            return time_1.msToTimeString(Math.abs(diff));
        },
        enumerable: true,
        configurable: true
    });
    return Flight;
}());
exports.Flight = Flight;
//# sourceMappingURL=flight.js.map