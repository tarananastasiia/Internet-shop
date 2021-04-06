import { MobilePhones} from './mobile-phone';
export class PageDTO{
    constructor(
        public maxPrice:number,
        public minPrice:number,
        public phones: MobilePhones[],
        public phonesCount: number,
        public pageSize: number,
        public pageNumber: number,
        ) 
        { }
        
}