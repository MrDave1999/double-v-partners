import { ValidationError } from './validation-error.model';

describe('ValidationError', () => {
  it('should create an instance', () => {
    expect(new ValidationError()).toBeTruthy();
  });
});
