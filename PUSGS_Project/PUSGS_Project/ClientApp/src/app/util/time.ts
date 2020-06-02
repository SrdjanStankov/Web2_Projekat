// Collection of time util/helper functions

/**
 * Converts milliseconds to human readable format (ex. '2h 15m')
 * @param milliseconds
 */
export function msToTimeString(milliseconds: number): string {
  // source: https://stackoverflow.com/a/57525637/7387483

  //Get hours from milliseconds
  const hours = milliseconds / (1000 * 60 * 60);
  const absoluteHours = Math.floor(hours);
  const h = absoluteHours > 9 ? absoluteHours : "0" + absoluteHours;

  //Get remainder from hours and convert to minutes
  const minutes = (hours - absoluteHours) * 60;
  const absoluteMinutes = Math.floor(minutes);
  const m = absoluteMinutes > 9 ? absoluteMinutes : "0" + absoluteMinutes;

  return `${h}h ${m}m`;
}
