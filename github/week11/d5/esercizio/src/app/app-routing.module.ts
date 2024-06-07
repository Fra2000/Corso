import { NgModule } from '@angular/core';
import { RouterModule, Routes } from '@angular/router';
import { GuestGuard } from './auth/guest.guard';
import { AuthGuard } from './auth/auth.guard';

const routes: Routes = [
{ path: 'dashboard', loadChildren: () => import('./pages/dashboard/dashboard.module').then(m => m.DashboardModule),
  canActivate:[AuthGuard],
  canActivateChild:[AuthGuard]
 },
{ path: 'auth', loadChildren: () => import('./auth/auth.module').then(m => m.AuthModule),
  canActivate:[GuestGuard],
  canActivateChild:[GuestGuard]
 },
{ path: '', loadChildren: () => import('./pages/home/home.module').then(m => m.HomeModule)

 }
];

@NgModule({
  imports: [RouterModule.forRoot(routes)],
  exports: [RouterModule]
})
export class AppRoutingModule { }
