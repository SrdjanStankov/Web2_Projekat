"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var User = /** @class */ (function () {
    function User(_a) {
        var _b = _a === void 0 ? {} : _a, _c = _b.name, name = _c === void 0 ? "" : _c, _d = _b.lastName, lastName = _d === void 0 ? "" : _d, _e = _b.city, city = _e === void 0 ? "" : _e, _f = _b.phone, phone = _f === void 0 ? "" : _f, _g = _b.email, email = _g === void 0 ? "" : _g, _h = _b.password, password = _h === void 0 ? "" : _h, _j = _b.friends, friends = _j === void 0 ? [] : _j;
        this.name = name;
        this.email = email;
        this.lastName = lastName;
        this.city = city;
        this.phone = phone;
        this.password = password;
        this.friends = friends;
    }
    return User;
}());
exports.User = User;
//# sourceMappingURL=user.js.map