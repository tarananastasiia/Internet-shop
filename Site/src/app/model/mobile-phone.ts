import { LinkToPhoto} from './linkToPhoto';

export class MobilePhones{
    constructor(
        public id: number,
        public category: string,
        public vendorCode: number,
        public modificationArticle: string,
        public name: string,
        public price: number,
        public quantity: number,
        public description: string,
        public manufacturer: string,
        public photo: string,
        public linkToPhoto: Array<LinkToPhoto>,
        public colour: string
        ) 
        { }   
}