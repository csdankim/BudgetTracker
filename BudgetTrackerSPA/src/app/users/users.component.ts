import { Component, Input, OnInit } from '@angular/core';
import { ActivatedRoute } from '@angular/router';
import { UserService } from '../core/services/user.service';
import { UserDetail } from '../shared/models/user-deail';

@Component({
  selector: 'app-users',
  templateUrl: './users.component.html',
  styleUrls: ['./users.component.css']
})
export class UsersComponent implements OnInit {
  @Input() user: UserDetail | undefined;
  @Input() id!: number;

  constructor(private userService: UserService, private route: ActivatedRoute) { }

  ngOnChanges() {

  }

  ngOnInit() {
    console.log('inside ngOnInit method');
    this.route.paramMap.subscribe(
      params => {
        this.id = +params.getAll('id');
        this.userService.getUserAsync(this.id).subscribe(
          u => {
            this.user = u;
            console.table(this.user);
          }
        )
      }
    )
  }

  ngOnDestroy() {
    console.log('inside ngOnDestroy method');
  }

}
