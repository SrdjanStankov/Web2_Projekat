"use strict";
var __extends = (this && this.__extends) || (function () {
    var extendStatics = function (d, b) {
        extendStatics = Object.setPrototypeOf ||
            ({ __proto__: [] } instanceof Array && function (d, b) { d.__proto__ = b; }) ||
            function (d, b) { for (var p in b) if (b.hasOwnProperty(p)) d[p] = b[p]; };
        return extendStatics(d, b);
    };
    return function (d, b) {
        extendStatics(d, b);
        function __() { this.constructor = d; }
        d.prototype = b === null ? Object.create(b) : (__.prototype = b.prototype, new __());
    };
})();
Object.defineProperty(exports, "__esModule", { value: true });
var user_1 = require("./user");
var RentACarAdmin = /** @class */ (function (_super) {
    __extends(RentACarAdmin, _super);
    function RentACarAdmin(name, lastName, city, phone, email, password, friends) {
        if (name === void 0) { name = ""; }
        if (lastName === void 0) { lastName = ""; }
        if (city === void 0) { city = ""; }
        if (phone === void 0) { phone = ""; }
        if (email === void 0) { email = ""; }
        if (password === void 0) { password = ""; }
        if (friends === void 0) { friends = []; }
        var _this = _super.call(this, { name: name, email: email, lastName: lastName, city: city, phone: phone, password: password, friends: friends }) || this;
        _this.IsRentACarAdmin = true;
        return _this;
    }
    return RentACarAdmin;
}(user_1.User));
exports.RentACarAdmin = RentACarAdmin;
//# sourceMappingURL=RentACarAdmin.js.map