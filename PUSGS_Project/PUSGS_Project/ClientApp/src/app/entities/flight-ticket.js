"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var FlightTicket = /** @class */ (function () {
    function FlightTicket(_a) {
        var _b = _a === void 0 ? {} : _a, _c = _b.ticketOwnerEmail, ticketOwnerEmail = _c === void 0 ? "" : _c, _d = _b.flightId, flightId = _d === void 0 ? -1 : _d, _e = _b.flightSeatId, flightSeatId = _e === void 0 ? -1 : _e, _f = _b.discount, discount = _f === void 0 ? 0 : _f, _g = _b.canReject, canReject = _g === void 0 ? true : _g;
        this.ticketOwnerEmail = ticketOwnerEmail;
        this.flightId = flightId;
        this.flightSeatId = flightSeatId;
        this.discount = discount;
        this.canReject = canReject;
    }
    return FlightTicket;
}());
exports.FlightTicket = FlightTicket;
var FlightTicketDetails = /** @class */ (function () {
    function FlightTicketDetails() {
    }
    return FlightTicketDetails;
}());
exports.FlightTicketDetails = FlightTicketDetails;
//# sourceMappingURL=flight-ticket.js.map