# LD FORMAT copy Form LDMICRO#
HARDWARE
Arduino ProMini(168)5V
IO LIST
X_Start at D4
X_Stop at D5
Y0 at D6
Y13 at D7
END
PROGRAM
RUNG
	PARALLEL
		CONTACTS X_Stop 1 0 0
		CONTACTS X_Start 0 0 0
	END
	TPC T01 2000 2000
	COIL R1 0 0 0 0
END
RUNG
	CONTACTS R1 0 0 0
	TPC T2 50 50
	COIL R2 0 0 0 0
END
RUNG
	CONTACTS R1 1 0 0
	TPC T3 250 250
	COIL R3 0 0 0 0
END
RUNG
	PARALLEL
		CONTACTS R2 0 0 0
		CONTACTS R3 0 0 0
	END
	PARALLEL
		COIL Y13 1 0 0 0
		COIL Y0 0 0 0 0
	END
END
