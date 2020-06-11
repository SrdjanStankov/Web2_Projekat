"use strict";
Object.defineProperty(exports, "__esModule", { value: true });
var storage_1 = require("../constants/storage");
function getRequirePassChange() {
    var requirePassChange = localStorage.getItem(storage_1.STORAGE_PASSCHG_KEY);
    return (requirePassChange !== 'undefined' && requirePassChange !== 'false' && !!requirePassChange);
}
exports.getRequirePassChange = getRequirePassChange;
//# sourceMappingURL=storage.js.map