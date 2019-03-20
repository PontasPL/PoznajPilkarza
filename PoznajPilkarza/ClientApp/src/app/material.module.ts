import { NgModule } from '@angular/core';

import {
    MatSidenavModule,
    MatToolbarModule,
    MatIconModule,
    MatListModule,
    MatCardModule,
    MatButtonModule,
    MatTableModule,
    MatSelectModule,
    MatPaginatorModule,
    MatSortModule,
    MatAutocompleteModule,
    MatInputModule,
    MatProgressSpinnerModule,
    MatCheckboxModule
} from '@angular/material';

@NgModule({
    imports: [
        MatSidenavModule,
        MatToolbarModule,
        MatIconModule,
        MatListModule,
        MatCardModule,
        MatButtonModule,
        MatTableModule,
        MatSelectModule,
        MatPaginatorModule,
        MatSortModule,
        MatAutocompleteModule,
        MatInputModule,
        MatProgressSpinnerModule,
        MatCheckboxModule
    ],
    exports: [
        MatSidenavModule,
        MatToolbarModule,
        MatIconModule,
        MatListModule,
        MatCardModule,
        MatSelectModule,
        MatButtonModule,
        MatTableModule,
        MatPaginatorModule,
        MatSortModule,
        MatAutocompleteModule,
        MatInputModule,
        MatProgressSpinnerModule,
        MatCheckboxModule
    ]
})
export class MaterialModule { }
