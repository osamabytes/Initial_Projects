import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { AuthenticationResponseDto } from 'src/app/interfaces/AuthenticationResponseDto.interface';
import { RegistrationResponseDto } from 'src/app/interfaces/RegistrationResponseDto.interface';
import { UserForAuthenticationDto } from 'src/app/interfaces/UserForAuthenticationDto.interface';
import { UserRegistrationDto } from 'src/app/interfaces/UserRegistrationDto.interface';
import { environment } from 'src/environments/environment';
import { StorageService } from './storage.service';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  baseApiUrl: String = environment.baseUrl;

  constructor(private http: HttpClient, private storage: StorageService) { }

  public registerUser(route: string, body: UserRegistrationDto){
    return this.http.post<RegistrationResponseDto> (this.baseApiUrl + route, body);
  }

  public loginUser(route: string, body: UserForAuthenticationDto){
    return this.http.post<AuthenticationResponseDto> (this.baseApiUrl + route, body);
  }

  public CheckLoginStatus(status: Number){
    if(this.storage.Get('token') != null && status == 401){
      this.storage.Delete('token');
      
      return false;
    }

    return true;
  }
}
