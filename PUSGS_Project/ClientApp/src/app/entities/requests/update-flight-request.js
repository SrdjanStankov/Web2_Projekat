"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var UpdateFlightRequest = /** @class */ (function () {
    function UpdateFlightRequest(_a) {
        var _b = _a === void 0 ? {} : _a, _c = _b.departureTime, departureTime = _c === void 0 ? new Date() : _c, _d = _b.arrivalTime, arrivalTime = _d === void 0 ? new Date() : _d, _e = _b.travelLength, travelLength = _e === void 0 ? 0 : _e, _f = _b.ticketPrice, ticketPrice = _f === void 0 ? 0 : _f, _g = _b.numberOfChangeovers, numberOfChangeovers = _g === void 0 ? 0 : _g;
        this.departureTime = new Date();
        this.arrivalTime = new Date();
        this.departureTime = departureTime;
        this.arrivalTime = arrivalTime;
        this.travelLength = travelLength;
        this.ticketPrice = ticketPrice;
        this.numberOfChangeovers = numberOfChangeovers;
    }
    return UpdateFlightRequest;
}());
exports.UpdateFlightRequest = UpdateFlightRequest;
//# sourceMappingURL=update-flight-request.js.map