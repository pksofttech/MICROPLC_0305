# LD FORMAT copy Form LDMICRO#
HARDWARE
Arduino UNO R3
IO LIST
X_BTN_ON at A5
X_BTN_START at A4
X_WATER_FULL at A3
Y_DN at D5
Y_LED_RINSE at D7
Y_LED_WASH at D6
Y_MOTER_L at D3
Y_MOTER_R at D2
Y_WATER_IN at D4
END
PROGRAM
RUNG
	CONTACTS X_BTN_ON 0 0 0
	TON T01 500000
	CTC C_POWER 3
END
RUNG
	GRT C_POWER 0
	COIL R_POWER 0 0 0 0
END
RUNG
	EQU C_POWER 1
	COIL R_WASH 0 0 0 0
END
RUNG
	EQU C_POWER 2
	COIL R_RINSE 0 0 0 0
END
RUNG
	EQU C_POWER 3
	COIL R_AUTO 0 0 0 0
END
RUNG
	CONTACTS R_WASH 0 0 0
	TPC T_02 200 500
	COIL R_WASH_LED 0 0 0 0
END
RUNG
	CONTACTS R_RINSE 0 0 0
	TPC T_03 200 500
	COIL R_RINSE_LED 0 0 0 0
END
RUNG
	CONTACTS R_AUTO 0 0 0
	TPC T_04 200 500
	COIL R_AUTO_LED 0 0 0 0
END
RUNG
	CONTACTS X_BTN_START 0 0 0
	PARALLEL
		SERIES
			CONTACTS R_WASH 0 0 0
			CONTACTS R_RINSE_START 1 0 0
			TON T05 1000000
			COIL R_WASH_START 0 1 0 0
		END
		SERIES
			CONTACTS R_RINSE 0 0 0
			CONTACTS R_WASH_START 1 0 0
			TON T06 1000000
			COIL R_RINSE_START 0 1 0 0
		END
	END
END
RUNG
	CONTACTS R_RINSE 0 0 0
	CONTACTS X_BTN_START 0 0 0
	CONTACTS R_WASH_START 1 0 0
	TON T03 2000000
	COIL R_RINSE_START 0 1 0 0
END
RUNG
	CONTACTS R_POWER 0 0 0
	CONTACTS R_AUTO 0 0 0
	CONTACTS X_BTN_START 0 0 0
	CONTACTS R_WASH_START 1 0 0
	CONTACTS R_RINSE_LED 1 0 0
	TON T04 2000000
	COIL R_AUTO_START 0 1 0 0
END
RUNG
	CONTACTS R_POWER 1 0 0
	PARALLEL
		COIL R_WASH_START 0 0 1 0
		COIL R_RINSE_START 0 0 1 0
		COIL R_AUTO_START 0 0 1 0
		COIL R_WATER_OK 0 0 1 0
		COIL Y_WATER_IN 0 0 1 0
	END
END
RUNG
	COMMENT *******************Out put
END
RUNG
	PARALLEL
		EQU C_POWER 1
		CONTACTS R_WASH_LED 0 0 0
		CONTACTS R_AUTO_LED 0 0 0
		CONTACTS R_WASH_START 0 0 0
	END
	COIL Y_LED_WASH 0 0 0 0
END
RUNG
	PARALLEL
		EQU C_POWER 1
		CONTACTS R_RINSE_LED 0 0 0
		CONTACTS R_AUTO_LED 0 0 0
		CONTACTS R_RINSE_START 0 0 0
	END
	COIL Y_LED_RINSE 0 0 0 0
END
RUNG
	COMMENT WASH
END
RUNG
	CONTACTS R_WASH_START 0 0 0
	CONTACTS R_WASH_DN 0 0 0
	OSR
	COIL Y_WATER_IN 0 1 0 0
END
RUNG
	CONTACTS X_WATER_FULL 0 0 0
	PARALLEL
		COIL Y_WATER_IN 0 0 1 0
		SERIES
			CONTACTS R_WASH_DN 1 0 0
			COIL R_WATER_OK 0 1 0 0
		END
	END
END
RUNG
	CONTACTS R_WASH_START 0 0 0
	CONTACTS R_WATER_OK 0 0 0
	TPC T_WASH 5000 5000
	COIL R_MOTER 0 0 0 0
END
RUNG
	CONTACTS R_WASH_START 0 0 0
	CONTACTS R_WATER_OK 0 0 0
	PARALLEL
		COIL R_WASH_RUN 0 1 0 0
		SERIES
			TON TEND_WASH 30000000
			PARALLEL
				COIL R_WASH_RUN 0 0 1 0
				COIL R_WASH_DN 0 0 1 0
				COIL R_WATER_OK 0 0 1 0
			END
		END
	END
END
RUNG
	CONTACTS R_WASH_DN 0 0 0
	TON T_WASH_DN 60000000
	PARALLEL
		COIL R_WASH_DN 0 0 1 0
		COIL R_WASH_START 0 0 1 0
	END
END
RUNG
	PARALLEL
		SERIES
			CONTACTS R_WASH_RUN 0 0 0
			CONTACTS R_WATER_OK 0 0 0
			CONTACTS R_MOTER 0 0 0
			TON T_MR 1000000
		END
		SERIES
			CONTACTS R_RINSE_RUN 0 0 0
			CONTACTS R_WASH_DN 1 0 0
			CONTACTS Y_DN 0 0 0
			TON T_DN 7000000
		END
	END
	COIL Y_MOTER_R 0 0 0 0
END
RUNG
	CONTACTS R_WASH_RUN 0 0 0
	CONTACTS R_WATER_OK 0 0 0
	CONTACTS R_MOTER 1 0 0
	TON T_ML 1000000
	COIL Y_MOTER_L 0 0 0 0
END
RUNG
	COMMENT RAINE
END
RUNG
	CONTACTS R_RINSE_START 0 0 0
	PARALLEL
		COIL R_RINSE_RUN 0 0 0 0
		SERIES
			TON T_END_RINSE 60000000
			COIL R_RINSE_START 0 0 1 0
		END
	END
END
RUNG
	PARALLEL
		CONTACTS R_RINSE_RUN 0 0 0
		CONTACTS R_WASH_DN 0 0 0
		CONTACTS R_AUTO 0 0 0
	END
	COIL Y_DN 0 0 0 0
END
