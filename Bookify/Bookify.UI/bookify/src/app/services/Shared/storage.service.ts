import { Injectable } from '@angular/core';

@Injectable({
  providedIn: 'root'
})
export class StorageService {

  constructor() { }

  public Save(key, data){
    localStorage.setItem(key, data);
  }

  public Get(key){
    return localStorage.getItem(key);
  }

  public Delete(key){
    localStorage.removeItem(key);
  }
}
