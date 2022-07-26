import { Book } from "../models/book.model";
import { Category } from "../models/category.model";

export interface BookCategoriesDto{
    Book: Book,
    Categories: Category[],
    Image1: Blob,
    Image2: Blob
}