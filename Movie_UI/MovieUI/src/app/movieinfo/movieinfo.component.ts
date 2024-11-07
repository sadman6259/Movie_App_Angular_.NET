import { Component } from '@angular/core';
import { movieService } from '../movie.service';
import { HttpClient } from '@angular/common/http';
import { Router } from '@angular/router';
import { movies } from '../movie';
import { Observable } from 'rxjs';
import { FormsModule } from '@angular/forms';
import { CommonModule } from '@angular/common';
import {NgxPaginationModule} from 'ngx-pagination';
import { DomSanitizer, SafeResourceUrl, SafeUrl} from '@angular/platform-browser';

@Component({
  selector: 'app-movieinfo',
  templateUrl: './movieinfo.component.html',
  styleUrls: ['./movieinfo.component.css']
})
export class MovieinfoComponent {
  
  constructor(public service:movieService,public http:HttpClient,public router:Router,private sanitizer: DomSanitizer) { }
  movie :any = [];  
  p = 1;
  imagePath:string;
  getMovie(title:string){
    
    this.service.getMovies(title)
    .subscribe(data => {
      this.movie = data;
      this.movie.forEach((element : any) => {
        let objectURL = 'data:image/png;base64,'+element.postarImage;
        element.postarImage = objectURL;
      });
    });
  }
    
}
