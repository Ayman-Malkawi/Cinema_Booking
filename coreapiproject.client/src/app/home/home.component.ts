import { Component } from '@angular/core';

@Component({
  selector: 'app-home',
  templateUrl: './home.component.html',
  styleUrl: './home.component.css'
})
export class HomeComponent {


  ngOnInit(): void {
    window.onload = () => {
      console.log("Page fully loaded");
      // هون بتحط أي أكشن بدك تعمله بعد تحميل الصفحة
    }
  }


}
