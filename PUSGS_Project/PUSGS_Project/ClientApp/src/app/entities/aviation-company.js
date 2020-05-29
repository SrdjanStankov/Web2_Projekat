"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var location_1 = require("./location");
var AviationCompany = /** @class */ (function () {
    function AviationCompany() {
        this.address = new location_1.Location();
    }
    Object.defineProperty(AviationCompany.prototype, "averageRating", {
        get: function () {
            return 5;
        },
        enumerable: true,
        configurable: true
    });
    return AviationCompany;
}());
exports.AviationCompany = AviationCompany;
//# sourceMappingURL=aviation-company.js.map