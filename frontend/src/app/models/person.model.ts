export class Person {
    names: string = '';
    lastNames: string = '';
    document: string = '';
    documentType: number = 1;
    email: string = '';

    Clear(): void 
    {
        this.names = '';
        this.lastNames = '';
        this.document = '';
        this.documentType = 1;
        this.email = '';
    }
}
