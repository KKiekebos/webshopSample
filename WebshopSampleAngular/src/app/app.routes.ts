import { Routes } from '@angular/router';
import { DetailsComponent } from './components/DetailsComponent/details.component';
import { HomeComponent } from './components/HomeComponent/home.component';

export const routes: Routes = [
    {path: "details/:id", component: DetailsComponent},
    {path: "home", component: HomeComponent},
];
