import { BookShop } from "./bookshop.model";
import { User } from "./user.model";

export interface UserBookShop{
    Id: string,
    UserId: string,
    User: User,
    BookshopId: string,
    Bookshop: BookShop
}