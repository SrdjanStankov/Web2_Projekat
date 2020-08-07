"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FlightSeatReservation = /** @class */ (function () {
    function FlightSeatReservation(_a) {
        var _b = _a === void 0 ? {} : _a, _c = _b.ticketOwnerEmail, ticketOwnerEmail = _c === void 0 ? "" : _c, _d = _b.flightId, flightId = _d === void 0 ? -1 : _d, _e = _b.flightSeatId, flightSeatId = _e === void 0 ? -1 : _e, _f = _b.flightSeatNumber, flightSeatNumber = _f === void 0 ? -1 : _f;
        this.ticketOwnerEmail = ticketOwnerEmail;
        this.flightId = flightId;
        this.flightSeatId = flightSeatId;
        this.flightSeatNumber = flightSeatNumber;
    }
    return FlightSeatReservation;
}());
exports.FlightSeatReservation = FlightSeatReservation;
//# sourceMappingURL=flight-seat-reservation.js.map