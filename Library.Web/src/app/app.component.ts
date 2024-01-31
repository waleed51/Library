import { Component } from '@angular/core';
import { LoaderService } from './modules/shared/Loader/loader-service.service';
import { Subscription } from 'rxjs';

@Component({
  selector: 'app-root',
  templateUrl: './app.component.html',
  styleUrls: ['./app.component.css']
})
export class AppComponent {
  title = 'Library.Web';
  isLoading = this.loadingService.isLoading;
   loadingSubscription: Subscription;

  constructor(public loadingService: LoaderService) {
    this.loadingSubscription = this.isLoading.subscribe(isLoading => {
      if (isLoading) {
        document.body.style.overflow = 'hidden';
      } else {
        document.body.style.overflow = 'auto';
      }
    });
  }
  
  ngOnDestroy() {
    this.loadingSubscription.unsubscribe();
  }
}
