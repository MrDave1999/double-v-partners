export class ValidationError {
    isSuccess: boolean = true;
    message: string= '';
    errors: Array<string> = [];

    Failure(message: string, errors: Array<string>): void
    {
        this.isSuccess = false;
        this.message = message;
        this.errors = errors;
    }

    Success(message: string): void 
    {
        this.isSuccess = true;
        this.message = message;
        this.errors = [];
    }
}
