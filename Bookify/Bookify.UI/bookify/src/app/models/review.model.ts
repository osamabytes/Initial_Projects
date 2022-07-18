import { Book } from "./book.model";
import { User } from "./user.model";

export interface Review{
    Id: string,
    Rating: Number,
    Reviews: string,
    UserId: string,
    User: User,
    BookId: string,
    Book: Book,
}