# LD FORMAT copy Form LDMICRO#
HARDWARE
Arduino UNO R3
IO LIST
X_btn_on at -
END
PROGRAM
RUNG
	CONTACTS X_btn_on 0 0 0
	TON T01 500000
	CTC C_mode 3
END
RUNG
	EQU C_mode 0
	COIL R_off 0 0 0 0
END
RUNG
	EQU C_mode 1
	COIL R_wash_mode 0 0 0 0
END
RUNG
	EQU C_mode 2
	COIL R_spin_mode 0 0 0 0
END
RUNG
	EQU C_mode 3
	COIL R_auto_mode 0 0 0 0
END
