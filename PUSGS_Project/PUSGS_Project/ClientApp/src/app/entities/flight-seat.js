"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FlightSeat = /** @class */ (function () {
    function FlightSeat() {
    }
    Object.defineProperty(FlightSeat.prototype, "isReserved", {
        get: function () {
            return !!this.reservedById;
        },
        enumerable: true,
        configurable: true
    });
    return FlightSeat;
}());
exports.FlightSeat = FlightSeat;
//# sourceMappingURL=flight-seat.js.map