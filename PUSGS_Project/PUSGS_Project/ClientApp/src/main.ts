import { enableProdMode } from "@angular/core";
import { platformBrowserDynamic } from "@angular/platform-browser-dynamic";

import { AppModule } from "./app/app.module";
import { environment } from "./environments/environment";

//export function getBaseUrl() {
//  if (environment.startedByDotNet === false) {
//    return environment.apiBaseUrl;
//  }
//  return document.getElementsByTagName("base")[0].href;
//}

export function getBaseUserUrl() {
  return environment.apiBaseUserUrl;
}

export function getBaseAvioUrl() {
  return environment.apiBaseAvioUrl;
}

export function getBaseRentACarUrl() {
  return environment.apiBaseRentACarUrl;
}

const providers = [
  { provide: "BASE_USER_URL", useFactory: getBaseUserUrl, deps: [] },
  { provide: "BASE_AVIO_URL", useFactory: getBaseAvioUrl, deps: [] },
  { provide: "BASE_RENTACAR_URL", useFactory: getBaseRentACarUrl, deps: [] }
];

if (environment.production) {
  enableProdMode();
}

platformBrowserDynamic(providers)
  .bootstrapModule(AppModule)
  .catch((err) => console.log(err));
