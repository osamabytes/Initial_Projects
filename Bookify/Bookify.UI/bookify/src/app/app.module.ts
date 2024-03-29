import { HttpClientModule, HTTP_INTERCEPTORS } from "@angular/common/http";
import { BrowserModule } from "@angular/platform-browser";
import { NgModule } from "@angular/core";

import { AppRoutingModule } from "./app-routing.module";
import { AppComponent } from "./app.component";

import { ToastrModule } from 'ngx-toastr';
import { BrowserAnimationsModule } from '@angular/platform-browser/animations';

import { NgHttpLoaderModule } from 'ng-http-loader';
import { NgMultiSelectDropDownModule } from 'ng-multiselect-dropdown';

// layouts
import { AdminComponent } from "./layouts/admin/admin.component";
import { AuthComponent } from "./layouts/auth/auth.component";

// admin views
import { DashboardComponent } from "./views/admin/dashboard/dashboard.component";
import { MapsComponent } from "./views/admin/maps/maps.component";
import { SettingsComponent } from "./views/admin/settings/settings.component";
import { TablesComponent } from "./views/admin/tables/tables.component";

// auth views
import { LoginComponent } from "./views/auth/login/login.component";
import { RegisterComponent } from "./views/auth/register/register.component";

// no layouts views
import { IndexComponent } from "./views/index/index.component";
import { LandingComponent } from "./views/landing/landing.component";
import { ProfileComponent } from "./views/profile/profile.component";

// components for views and layouts

import { AdminNavbarComponent } from "./components/navbars/admin-navbar/admin-navbar.component";
import { AuthNavbarComponent } from "./components/navbars/auth-navbar/auth-navbar.component";
import { CardBarChartComponent } from "./components/cards/card-bar-chart/card-bar-chart.component";
import { CardLineChartComponent } from "./components/cards/card-line-chart/card-line-chart.component";
import { CardPageVisitsComponent } from "./components/cards/card-page-visits/card-page-visits.component";
import { CardProfileComponent } from "./components/cards/card-profile/card-profile.component";
import { CardSettingsComponent } from "./components/cards/card-settings/card-settings.component";
import { CardSocialTrafficComponent } from "./components/cards/card-social-traffic/card-social-traffic.component";
import { CardStatsComponent } from "./components/cards/card-stats/card-stats.component";
import { CardTableComponent } from "./components/cards/card-table/card-table.component";
import { FooterAdminComponent } from "./components/footers/footer-admin/footer-admin.component";
import { FooterComponent } from "./components/footers/footer/footer.component";
import { FooterSmallComponent } from "./components/footers/footer-small/footer-small.component";
import { HeaderStatsComponent } from "./components/headers/header-stats/header-stats.component";
import { IndexNavbarComponent } from "./components/navbars/index-navbar/index-navbar.component";
import { MapExampleComponent } from "./components/maps/map-example/map-example.component";
import { IndexDropdownComponent } from "./components/dropdowns/index-dropdown/index-dropdown.component";
import { TableDropdownComponent } from "./components/dropdowns/table-dropdown/table-dropdown.component";
import { PagesDropdownComponent } from "./components/dropdowns/pages-dropdown/pages-dropdown.component";
import { NotificationDropdownComponent } from "./components/dropdowns/notification-dropdown/notification-dropdown.component";
import { SidebarComponent } from "./components/sidebar/sidebar.component";
import { UserDropdownComponent } from "./components/dropdowns/user-dropdown/user-dropdown.component";
import { AddCategoryComponent } from './views/admin/category/add-category/add-category.component';
import { ViewAllBookshopsComponent } from './views/admin/bookshops/view-all-bookshops/view-all-bookshops.component';
import { ViewAllBooksComponent } from './views/admin/books/view-all-books/view-all-books.component';
import { AddBookComponent } from './views/admin/books/add-book/add-book.component';
import { ViewAllCustomersComponent } from './views/admin/customers/view-all-customers/view-all-customers.component';
import { BooksTableComponent } from './components/cards/card-books/books-table/books-table.component';
import { AdminBookDropdownComponent } from './components/dropdowns/admin_book_dropdown/admin-book-dropdown/admin-book-dropdown.component';
import { AddBookCardComponent } from './components/cards/card-books/add-book-card/add-book-card.component';
import { AddBookCategoryComponent } from './components/cards/card-books/add-book-category/add-book-category.component';
import { BookshopsTableComponent } from './components/cards/card-bookshops/bookshops-table/bookshops-table.component';
import { AdminBookshopDropdownComponent } from './components/dropdowns/admin-bookshop-dropdown/admin-bookshop-dropdown.component';
import { CustomersTableComponent } from './components/cards/card-customers/customers-table/customers-table.component';
import { AdminCustomerDropdownComponent } from './components/dropdowns/admin-customer-dropdown/admin-customer-dropdown.component';
import { FormsModule } from "@angular/forms";
import { InterceptorService } from "./services/Shared/Network/interceptor.service";
import { CreatebookshopComponent } from "./components/cards/card-bookshops/createbookshop/createbookshop.component";

@NgModule({
  declarations: [
    AppComponent,
    DashboardComponent,
    CardBarChartComponent,
    CardLineChartComponent,
    IndexDropdownComponent,
    PagesDropdownComponent,
    TableDropdownComponent,
    NotificationDropdownComponent,
    UserDropdownComponent,
    SidebarComponent,
    FooterComponent,
    FooterSmallComponent,
    FooterAdminComponent,
    CardPageVisitsComponent,
    CardProfileComponent,
    CardSettingsComponent,
    CardSocialTrafficComponent,
    CardStatsComponent,
    CardTableComponent,
    HeaderStatsComponent,
    MapExampleComponent,
    AuthNavbarComponent,
    AdminNavbarComponent,
    IndexNavbarComponent,
    AdminComponent,
    AuthComponent,
    MapsComponent,
    SettingsComponent,
    TablesComponent,
    LoginComponent,
    RegisterComponent,
    IndexComponent,
    LandingComponent,
    ProfileComponent,
    AddCategoryComponent,
    ViewAllBookshopsComponent,
    ViewAllBooksComponent,
    AddBookComponent,
    ViewAllCustomersComponent,
    BooksTableComponent,
    AdminBookDropdownComponent,
    AddBookCardComponent,
    AddBookCategoryComponent,
    BookshopsTableComponent,
    AdminBookshopDropdownComponent,
    CustomersTableComponent,
    AdminCustomerDropdownComponent,
    CreatebookshopComponent
  ],
  imports: [BrowserModule, BrowserAnimationsModule, AppRoutingModule, HttpClientModule, FormsModule, ToastrModule.forRoot(), 
            NgHttpLoaderModule.forRoot(), NgMultiSelectDropDownModule.forRoot()],
  providers: [
    {
      provide: HTTP_INTERCEPTORS,
      useClass: InterceptorService,
      multi: true
    }
  ],
  bootstrap: [AppComponent],
})
export class AppModule {}
