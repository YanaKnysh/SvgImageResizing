export class DataService{

    private data: number[] = [ 150, 100];

    getInitialSize(): number[] {

        return this.data;
    }
    // addData(name: string){
    //
    //     this.data.push(name);
    // }
}