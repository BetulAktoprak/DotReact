import TextField from "@mui/material/TextField";
import InputAdornment from "@mui/material/InputAdornment";
import { FaUser } from "react-icons/fa";
import { MdEmail } from "react-icons/md";
import { RiLockPasswordLine } from "react-icons/ri";
import { Button } from "@mui/material";
import { useFormik } from "formik";
import { registerPageSchema } from "../schemas/RegisterPageSchema";
import api from "../services/api";
import { toast } from "react-toastify";
import { useNavigate } from "react-router-dom";
import "../css/RegisterPage.css";

function RegisterPage() {
  const navigate = useNavigate();

  const submit = async (values: any) => {
    try {
      const response = await api.post("/users/register", values);
      if (response) {
        toast.success("Kayıt başarılı.");
        clear();
        navigate("/login");
        console.log(response.data);
      }
    } catch (error) {
      toast.error("Kayıt sırasında hata oluştu.");
      console.log(error);
    }
  };

  const { values, handleSubmit, handleChange, errors, resetForm } = useFormik({
    initialValues: {
      username: "",
      email: "",
      password: "",
    },
    onSubmit: submit,
    validationSchema: registerPageSchema,
  });

  const clear = () => {
    resetForm();
  };

  return (
    <div className="register">
      <form className="form-div" onSubmit={handleSubmit}>
        <h3 className="form-h3">Kayıt Ol</h3>
        <TextField
          id="username"
          placeholder="Kullanıcı Adı"
          value={values.username}
          onChange={handleChange}
          variant="standard"
          fullWidth
          sx={{ marginBottom: "25px" }}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <FaUser />
                </InputAdornment>
              ),
            },
          }}
          helperText={
            errors.username && (
              <span style={{ color: "red" }}>{errors.username}</span>
            )
          }
        />
        <TextField
          id="email"
          placeholder="Email"
          value={values.email}
          onChange={handleChange}
          variant="standard"
          fullWidth
          sx={{ marginBottom: "25px" }}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <MdEmail />
                </InputAdornment>
              ),
            },
          }}
          helperText={
            errors.email && <span style={{ color: "red" }}>{errors.email}</span>
          }
        />
        <TextField
          id="password"
          placeholder="Şifre"
          value={values.password}
          onChange={handleChange}
          type="password"
          variant="standard"
          fullWidth
          sx={{ marginBottom: "25px" }}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <RiLockPasswordLine />
                </InputAdornment>
              ),
            },
          }}
          helperText={
            errors.password && (
              <span style={{ color: "red" }}>{errors.password}</span>
            )
          }
        />
        <div>
          <Button
            type="submit"
            size="small"
            sx={{ textTransform: "none", height: "28px", marginRight: "10px" }}
            variant="contained"
            color="warning"
          >
            Kayıt Ol
          </Button>
          <Button
            size="small"
            sx={{ textTransform: "none", height: "28px" }}
            variant="contained"
            color="inherit"
            onClick={clear}
          >
            Temizle
          </Button>
        </div>
      </form>
    </div>
  );
}

export default RegisterPage;
