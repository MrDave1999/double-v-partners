export class User {
    userName: string = '';
    password: string = '';

    Clear(): void 
    {
        this.userName = '';
        this.password = '';
    }
}
