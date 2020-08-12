import { Car } from './car';

describe('Car', () => {
  it('should create an instance', () => {
    expect(new Car(null, null, null, null, null, null, null)).toBeTruthy();
  });
});
