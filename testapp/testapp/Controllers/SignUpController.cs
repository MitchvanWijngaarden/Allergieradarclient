using System;
using System.Collections.Generic;
using System.Text;
using testapp.Models;
using testapp.Services;
using testapp.Views;

namespace testapp.Controllers
{
    class SignUpController
    {
        private SignUpPage view;

        public SignUpController(SignUpPage view)
        {
            this.view = view;
        }

        public void SubmitUser(User user)
        {
            SignUpService.Instance.SubmitUser(user);
        }
    }
}
