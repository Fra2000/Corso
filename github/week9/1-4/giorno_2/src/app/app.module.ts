import { NgModule } from '@angular/core';
import { BrowserModule } from '@angular/platform-browser';

import { AppRoutingModule } from './app-routing.module';
import { AppComponent } from './app.component';
import { PrimocomponenteComponent } from './components/primocomponente/primocomponente.component';
import { SecondocomponenteComponent } from './components/secondocomponente/secondocomponente.component';
import { TerzocomponenteComponent } from './components/terzocomponente/terzocomponente.component';

@NgModule({
  declarations: [
    AppComponent,
    PrimocomponenteComponent,
    SecondocomponenteComponent,
    TerzocomponenteComponent
  ],
  imports: [
    BrowserModule,
    AppRoutingModule
  ],
  providers: [],
  bootstrap: [AppComponent]
})
export class AppModule { }
