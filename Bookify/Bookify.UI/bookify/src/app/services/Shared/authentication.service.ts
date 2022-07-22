import { HttpClient } from '@angular/common/http';
import { Injectable } from '@angular/core';
import { RegistrationResponseDto } from 'src/app/interfaces/RegistrationResponseDto.interface';
import { UserRegistrationDto } from 'src/app/interfaces/UserRegistrationDto.interface';
import { environment } from 'src/environments/environment';

@Injectable({
  providedIn: 'root'
})
export class AuthenticationService {

  baseApiUrl: String = environment.baseUrl;

  constructor(private http: HttpClient) { }

  public registerUser(route: string, body: UserRegistrationDto){
    return this.http.post<RegistrationResponseDto> (this.baseApiUrl + route, body);
  }
}
