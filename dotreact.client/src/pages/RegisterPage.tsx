import TextField from "@mui/material/TextField";
import InputAdornment from "@mui/material/InputAdornment";
import { FaUser } from "react-icons/fa";
import { MdEmail } from "react-icons/md";
import { RiLockPasswordLine } from "react-icons/ri";
import "../css/RegisterPage.css";
import { Button } from "@mui/material";

function RegisterPage() {
  return (
    <div className="register">
      <h3>Kayıt Ol</h3>
      <form className="form-div">
        <TextField
          id="username"
          placeholder="Kullanıcı Adı"
          variant="standard"
          fullWidth
          sx={{marginBottom:"25px"}}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <FaUser />
                </InputAdornment>
              ),
            },
          }}
        />
        <TextField
          id="email"
          placeholder="Email"
          variant="standard"
          fullWidth
          sx={{marginBottom:"25px"}}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <MdEmail />
                </InputAdornment>
              ),
            },
          }}
        />
        <TextField
          id="password"
          placeholder="Şifre"
          type="password"
          variant="standard"
          fullWidth
          sx={{marginBottom:"25px"}}
          slotProps={{
            input: {
              startAdornment: (
                <InputAdornment position="start">
                  <RiLockPasswordLine />
                </InputAdornment>
              ),
            },
          }}
        />
        <div>
          <Button size="small" sx={{textTransform:"none", height:"28px", marginRight:"10px"}} variant="contained" color="warning">Kaydol</Button>
          <Button size="small" sx={{textTransform:"none", height:"28px"}} variant="contained" color="inherit">Temizle</Button>
        </div>
      </form>
    </div>
  );
}

export default RegisterPage;
