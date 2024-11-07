import { Injectable, ViewChild } from '@angular/core';
import { HttpClient, HttpHeaders, HttpParams } from '@angular/common/http';
import { Observable } from 'rxjs';
import { map } from 'rxjs/operators';
import { movies } from './movie';
import * as CryptoJS from 'crypto-js';

@Injectable({
  providedIn: 'root'
})
export class movieService {
  formData : any = {};
  Url='https://localhost:44336/api/movie';
  apiKey : string = "249a1a03-11b3-4e6f-946d-9947d90f76a4";
  encriptionKey:string = "SecretKeyForEncryption&Descryption";
  list : movies[];
  
  constructor(private http:HttpClient) { }

   encrypt (msg:string, pass:string) {
    // random salt for derivation
    var keySize = 256;
    var salt = CryptoJS.lib.WordArray.random(16);
    // well known algorithm to generate key
    var key = CryptoJS.PBKDF2(pass, salt, {
        keySize: keySize/32,
        iterations: 100
      });
    // random IV
    var iv = CryptoJS.lib.WordArray.random(128/8);      
    // specify everything explicitly
    var encrypted = CryptoJS.AES.encrypt(msg, key, { 
      iv: iv, 
      padding: CryptoJS.pad.Pkcs7,
      mode: CryptoJS.mode.CBC        
    });
    // combine everything together in base64 string
    var result = CryptoJS.enc.Base64.stringify(salt.concat(iv).concat(encrypted.ciphertext));
    return result;
  }

  encryptData(data: string, key: string): string {
    return CryptoJS.AES.encrypt(data, key).toString();
  }

  getMovies(title:string):Observable<movies[]>{
    return this.http.get<movies[]>(this.Url + "?s="+title + "&apikey="+ this.encryptData(this.apiKey,this.encriptionKey));
}
}
