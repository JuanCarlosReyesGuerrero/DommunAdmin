import { Component, OnInit } from "@angular/core";
import { FormBuilder, FormGroup, Validators } from "@angular/forms";
import { ActivatedRoute, Router } from "@angular/router";

// Login Auth
import { environment } from "../../../environments/environment";
import { AuthenticationService } from "../../core/services/auth.service";
import { AuthfakeauthenticationService } from "../../core/services/authfake.service";
import { first } from "rxjs/operators";
import { interval } from "rxjs";
import { NgbModal } from "@ng-bootstrap/ng-bootstrap";
import { LoginModel } from "src/app/core/models/login-model.class";
import { LoginService } from "src/app/core/services/login.service";
import { DommunConstants } from "src/app/common/constants.class";
import { ToastService } from "src/app/pages/ui/notifications/toast-service";

@Component({
  selector: "app-login",
  templateUrl: "./login.component.html",
  styleUrls: ["./login.component.scss"],
})

/**
 * Login Component
 */
export class LoginComponent implements OnInit {
  // Login Form
  //loginForm!: FormGroup;
  loginForm: any;
  loginModel!: LoginModel;
  submitted = false;
  fieldTextType!: boolean;
  error = "";
  returnUrl!: string;

  toast!: false;

  private formSubmitAttempt!: boolean;

  state!: boolean;

  // set the current year
  year: number = new Date().getFullYear();

  constructor(
    private formBuilder: FormBuilder,
    private authenticationService: AuthenticationService,
    private router: Router,
    private authFackservice: AuthfakeauthenticationService,
    private route: ActivatedRoute,
    private modalService: NgbModal,
    private loginService: LoginService,
    public toastService: ToastService
  ) {
    // redirect to home if already logged in
    if (this.authenticationService.currentUserValue) {
      this.router.navigate(["/"]);
    }
  }

  ngOnInit(): void {
    this.crearTokenLocalStorage();
    const contador = interval(55000);
    contador.subscribe((n) => {
      this.authenticationService.getToken().subscribe((resp) => {
        localStorage.setItem("token", resp.token);
      });
    });

    this.loginForm = this.formBuilder.group({
      email: ["admin@themesbrand.com", [Validators.required, Validators.email]],
      password: ["123456", [Validators.required]],
    });
    // get return url from route parameters or default to '/'
    this.returnUrl = this.route.snapshot.queryParams["returnUrl"] || "/";
  }

  isFieldInvalid(field: string) {
    return (
      (!this.loginForm.get(field).valid && this.loginForm.get(field).touched) ||
      (this.loginForm.get(field).untouched && this.formSubmitAttempt)
    );
  }

  onClickAceptar() {
    this.modalService.dismissAll();
  }

  onSubmit6() {
    this.state = false;
    if (this.loginForm.valid) {
      this.loginModel = this.loginForm.value;
      this.loginService.LogIn(this.loginModel).subscribe((data) => {
        sessionStorage.setItem("Email", this.loginModel.Email);
        localStorage.setItem("session", DommunConstants.TokenHash.key);
        this.authenticationService.currentUserSubject.next(
          DommunConstants.TokenHash.apiKey
        );
        this.authenticationService.login(true);

        if (data.success) {
          if (data.success === true) {
            sessionStorage.setItem("Email", this.loginModel.Email);
            localStorage.setItem("session", DommunConstants.TokenHash.key);
            this.authenticationService.currentUserSubject.next(
              DommunConstants.TokenHash.apiKey
            );
            this.authenticationService.login(true);

            localStorage.setItem('token', "fdsfsdfsdsfsdf")

            this.router.navigate(["/"]);
          } else {
            this.loginService.emailBackOffice = this.loginModel.Email;
            this.loginService.passwordBackOffice = this.loginModel.PasswordHash;
            this.router.navigate(["/login/xxxxxx"]);
          }
        } else {
          //this.notifyService.showError("Favor Verificar, Usuario y/o contraseña incorrectos", "No Autorizado")
          this.toastService.show(
            "Favor Verificar, Usuario y/o contraseña incorrectos",
            "No Autorizado"
          );
          this.state = true;
          this.authenticationService.login(false);
        }
      });
    } else {
      this.state = true;
      //this.notifyService.showError("Favor diligenciar usuario y contraseña", "Datos obligatorios")
    }
    this.formSubmitAttempt = true;
  }

  // convenience getter for easy access to form fields
  get f() {
    return this.loginForm.controls;
  }

  onSubmit() {
    this.submitted = true;
    if (this.loginForm.invalid) {
      return;
    } else {
      this.authFackservice
        .login(this.f["email"].value, this.f["password"].value)
        .pipe(first())
        .subscribe(
          (data) => {
            this.router.navigate(["/"]);
          },
          (error) => {
            this.error = error ? error : "";
          }
        );
    }
  }

  /**
   * Password Hide/Show
   */
  toggleFieldTextType() {
    this.fieldTextType = !this.fieldTextType;
  }

  crearTokenLocalStorage() {
    this.authenticationService.getToken().subscribe((resp) => {
      localStorage.setItem("token", resp.token);
    });
  }
}
