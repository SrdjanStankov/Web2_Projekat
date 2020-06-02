"use strict";
// Collection of time util/helper functions
Object.defineProperty(exports, "__esModule", { value: true });
/**
 * Converts milliseconds to human readable format (ex. '2h 15m')
 * @param milliseconds
 */
function msToTimeString(milliseconds) {
    // source: https://stackoverflow.com/a/57525637/7387483
    //Get hours from milliseconds
    var hours = milliseconds / (1000 * 60 * 60);
    var absoluteHours = Math.floor(hours);
    var h = absoluteHours > 9 ? absoluteHours : "0" + absoluteHours;
    //Get remainder from hours and convert to minutes
    var minutes = (hours - absoluteHours) * 60;
    var absoluteMinutes = Math.floor(minutes);
    var m = absoluteMinutes > 9 ? absoluteMinutes : "0" + absoluteMinutes;
    return h + "h " + m + "m";
}
exports.msToTimeString = msToTimeString;
//# sourceMappingURL=time.js.map